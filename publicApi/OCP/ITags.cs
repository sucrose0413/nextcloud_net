﻿using System;
using System.Collections;
using System.Collections.Generic;
namespace OCP
{
// FIXME: Where should I put this? Or should it be implemented as a Listener?
//\OC_Hook::connect('OC_User', 'post_deleteUser', Tags::class, 'post_deleteUser');

/**
 * Class for easily tagging objects by their id
 *
 * A tag can be e.g. 'Family', 'Work', 'Chore', 'Special Occation' or
 * anything else that is either parsed from a vobject or that the user chooses
 * to add.
 * Tag names are not case-sensitive, but will be saved with the case they
 * are entered in. If a user already has a tag 'family' for a type, and
 * tries to add a tag named 'Family' it will be silently ignored.
 * @since 6.0.0
 */

public interface ITags
    {

        /**
         * Check if any tags are saved for this type and user.
         *
         * @return boolean
         * @since 6.0.0
         */
        public bool isEmpty();

        /**
         * Returns an array mapping a given tag's properties to its values:
         * ['id' => 0, 'name' = 'Tag', 'owner' = 'User', 'type' => 'tagtype']
         *
         * @param string $id The ID of the tag that is going to be mapped
         * @return array|false
         * @since 8.0.0
         */
        // public bool getTag(string id);
        public IDictionary getTag(string id);

        /**
         * Get the tags for a specific user.
         *
         * This returns an array with id/name maps:
         * [
         *  ['id' => 0, 'name' = 'First tag'],
         *  ['id' => 1, 'name' = 'Second tag'],
         * ]
         *
         * @return array
         * @since 6.0.0
         */
        public IDictionary getTags();

        /**
         * Get a list of tags for the given item ids.
         *
         * This returns an array with object id / tag names:
         * [
         *   1 => array('First tag', 'Second tag'),
         *   2 => array('Second tag'),
         *   3 => array('Second tag', 'Third tag'),
         * ]
         *
         * @param array $objIds item ids
         * @return array|boolean with object id as key and an array
         * of tag names as value or false if an error occurred
         * @since 8.0.0
         */
        // public bool getTagsForObjects(IList<string> objIds);
        public IDictionary getTagsForObjects(IList<string> objIds);
        /**
         * Get a list of items tagged with $tag.
         *
         * Throws an exception if the tag could not be found.
         *
         * @param string|integer $tag Tag id or name.
         * @return array|false An array of object ids or false on error.
         * @since 6.0.0
         */
        public IDictionary getIdsForTag(string tag);

        /**
         * Checks whether a tag is already saved.
         *
         * @param string $name The name to check for.
         * @return bool
         * @since 6.0.0
         */
        public bool hasTag(string name);

        /**
         * Checks whether a tag is saved for the given user,
         * disregarding the ones shared with him or her.
         *
         * @param string $name The tag name to check for.
         * @param string $user The user whose tags are to be checked.
         * @return bool
         * @since 8.0.0
         */
        public bool userHasTag(string name, string user);

        /**
         * Add a new tag.
         *
         * @param string $name A string with a name of the tag
         * @return int|false the id of the added tag or false if it already exists.
         * @since 6.0.0
         */
        public int add(string name);

        /**
         * Rename tag.
         *
         * @param string|integer $from The name or ID of the existing tag
         * @param string $to The new name of the tag.
         * @return bool
         * @since 6.0.0
         */
        public bool rename(string from, string to);

        /**
         * Add a list of new tags.
         *
         * @param string[] $names A string with a name or an array of strings containing
         * the name(s) of the to add.
         * @param bool $sync When true, save the tags
         * @param int|null $id int Optional object id to add to this|these tag(s)
         * @return bool Returns false on error.
         * @since 6.0.0
         */
        public bool addMultiple(IList<string> names, bool sync= false, int? id = null);

        /**
         * Delete tag/object relations from the db
         *
         * @param array $ids The ids of the objects
         * @return boolean Returns false on error.
         * @since 6.0.0
         */
        public bool purgeObjects(IList<string> ids);

        /**
         * Get favorites for an object type
         *
         * @return array|false An array of object ids.
         * @since 6.0.0
         */
        public IList<string> getFavorites();

        /**
         * Add an object to favorites
         *
         * @param int $objid The id of the object
         * @return boolean
         * @since 6.0.0
         */
        public bool addToFavorites(int objid);

        /**
         * Remove an object from favorites
         *
         * @param int $objid The id of the object
         * @return boolean
         * @since 6.0.0
         */
        public bool removeFromFavorites(int objid);

        /**
         * Creates a tag/object relation.
         *
         * @param int $objid The id of the object
         * @param string $tag The id or name of the tag
         * @return boolean Returns false on database error.
         * @since 6.0.0
         */
        public bool tagAs(int objid, string tag);

        /**
         * Delete single tag/object relation from the db
         *
         * @param int $objid The id of the object
         * @param string $tag The id or name of the tag
         * @return boolean
         * @since 6.0.0
         */
        public bool unTag(int objid, string tag);

        /**
         * Delete tags from the database
         *
         * @param string[]|integer[] $names An array of tags (names or IDs) to delete
         * @return bool Returns false on error
         * @since 6.0.0
         */
        public bool delete(IList<string> names);

    }

}